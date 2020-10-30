import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { TreeviewConfig, TreeviewItem } from 'ngx-treeview';
import { EmployeeService } from 'src/services/employee.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  page = 1;
  itemsPerPage = 8;
  users = [];
  emps = [];
  items: TreeviewItem[];
  item = {
    text: 'Department',
    value: 0,
    children: [],
  };
  config = TreeviewConfig.create({
    hasAllCheckBox: true,
    hasFilter: true,
    hasCollapseExpand: true,
    decoupleChildFromParent: false,
    maxHeight: 400,
  });
  constructor(
    private service: EmployeeService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getEmpWithDept();
    this.getUser();
  }
  onSelectedChange(event: any) {
    let data = [];
    event.forEach((el) => {
      this.service.getEmployeeWithDept(el).subscribe(
        (val: any) => {
          data.push(val);
        },
        (err) => {
          this.toastr.error('Server Error');
        }
      );
    });
    this.users = data;
  }
  onFilterChange(event: any) {}
  getEmpWithDept() {
    this.service.getDeptWithAssociatedEmployee().subscribe(
      (val: any) => {
        this.emps = val;
        let temp;
        let innertemp;
        this.emps.forEach((emp) => {
          temp = {
            text: emp.department.name,
            value: emp.department.id,
            children: [],
          };
          emp.employees.forEach((element) => {
            innertemp = { text: element.name, value: element.id };
            temp.children.push(innertemp);
          });
          this.item.children.push(temp);
          this.items = [new TreeviewItem(this.item)];
        });
      },
      (err) => {
        this.toastr.error('Server Error');
      }
    );
  }

  getUser() {
    this.service.getAllEmployees().subscribe(
      (val: any) => {
        this.users = val;
      },
      (err) => {
        this.toastr.error('Server Error');
      }
    );
  }
  onDelete(id: any, name: any) {
    if (confirm('Are you sure to delete ' + name)) {
      this.service.deleteEmployee(id).subscribe(
        (val: any) => {
          this.toastr.success('Deleted!');
          this.getUser();
        },
        (err) => {
          if (err.status === 200) {
            this.toastr.success('Deleted!');
            this.getUser();
          } else {
            this.toastr.error('Server Error');
            console.log(err);
          }
        }
      );
    }
  }
}

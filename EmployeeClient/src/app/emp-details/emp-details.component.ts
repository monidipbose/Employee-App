import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from 'src/services/employee.service';

@Component({
  selector: 'app-emp-details',
  templateUrl: './emp-details.component.html',
  styleUrls: ['./emp-details.component.css'],
})
export class EmpDetailsComponent implements OnInit {
  emp: any;
  isEditable = false;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private service: EmployeeService
  ) {}

  ngOnInit(): void {
    this.getUser();
  }
  getUser() {
    this.service
      .getEmployeeWithDept(this.route.snapshot.paramMap.get('id'))
      .subscribe(
        (val: any) => {
          this.emp = val;
        },
        (err) => {
          this.toastr.error('Server Error');
        }
      );
  }
  save() {
    this.service.updateEmployee(this.emp.id, this.emp).subscribe(
      (val) => {
        this.toastr.success('Saved!');
        this.router.navigate(['/']);
      },
      (err) => {
        this.toastr.error('Server Error');
        console.log(err);
      }
    );
  }
  cancel() {
    this.router.navigate(['/']);
  }
  edit() {
    this.isEditable = !this.isEditable;
  }
}

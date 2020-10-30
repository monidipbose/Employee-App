import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from 'src/services/employee.service';

@Component({
  selector: 'app-add-update-form',
  templateUrl: './add-update-form.component.html',
  styleUrls: ['./add-update-form.component.css'],
})
export class AddUpdateFormComponent implements OnInit {
  user: any = {};
  constructor(
    private service: EmployeeService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {}
  onSubmit() {
    this.user.departmentId = +this.user.departmentId;
    this.service.addEmployee(this.user).subscribe(
      (val) => {
        this.router.navigate(['/']);
      },
      (err) => {
        this.toastr.error('Server Error');
        console.log(err);
      }
    );
  }
}

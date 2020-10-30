import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) {}

  getAllEmployees() {
    return this.http.get(this.baseUrl + 'Employee/all');
  }
  getEmployee(id: any) {
    return this.http.get(this.baseUrl + 'Employee/' + id);
  }
  getEmployeeWithDept(id: any) {
    return this.http.get(this.baseUrl + 'Employee/all/' + id);
  }
  getEmployeesByDept(
    id: any,
    pageSize: number | null,
    pageNumber: number | null
  ) {
    return this.http.get(
      this.baseUrl +
        'Employee/bydept/' +
        id +
        '?pageSize=' +
        pageSize +
        '&pageNumber=' +
        pageNumber
    );
  }
  getDeptWithAssociatedEmployee() {
    return this.http.get(this.baseUrl + 'Employee/departmentswithemployee');
  }
  addEmployee(data: any) {
    return this.http.post(this.baseUrl + 'Employee', data);
  }
  updateEmployee(id: any, data: any) {
    return this.http.put(this.baseUrl + 'Employee/' + id, data);
  }
  deleteEmployee(id: any) {
    return this.http.delete(this.baseUrl + 'Employee/' + id);
  }
}

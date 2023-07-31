import { Injectable } from '@angular/core';
import { Employees } from '../model/employees';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  readonly rootUrl='https://localhost:7147/api/';
  formData:Employees;
  constructor(private http:HttpClient) { }

  createEmployees(){
    console.log(this.formData);
    return this.http.post(this.rootUrl+'Employee/AddEmployee',this.formData);
  }

  updateEmployees(){
    return this.http.post(this.rootUrl+'Employee/UpdateEmployee/'+this.formData.Id,this.formData);
  }

  loadEmployees(){
    return this.http.get(this.rootUrl+'Employee/GetAllEmployees');
  }

  deleteEmployee(id){
    return this.http.delete(this.rootUrl+'Employee/DeleteEmployee/'+id);
  }
}

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { Employees } from 'src/app/model/employees';
import { EmployeesService } from 'src/app/service/employees.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {
  employeeList : {};
  title : any;
  @Input() subTitle : any;
  @Input() showHideSubTitle : boolean = false;
  @Output() emitSavedData = new EventEmitter<any>();
  constructor(public employees_service:EmployeesService,public toastr:ToastrService) { }

  ngOnInit(): void {
    this.resetForm();
    this.LoadAllEmployees();
    this.title = 'Employee Registration';
  }

  resetForm(form?:NgForm){
    if(form!=null)
    form.resetForm();
    this.employees_service.formData={
      Id:0,
      EmployeeCode:'',
      EmployeeName:'',
      EmployeeDesignation:''
    }
  }

  OnSubmit(form:NgForm){
    console.log("clicked");
    if(this.employees_service.formData.Id==0){
      this.CreateEmployees();
    }
    else{
      this.UpdateEmployees();
    }
    this.resetForm();
  }

  LoadAllEmployees(){
    this.employees_service.loadEmployees().subscribe(
      data=>{
        this.employeeList = data as Employees[];
        console.log(this.employeeList);
      }
    )
  }

  CreateEmployees(){
    this.employees_service.createEmployees().subscribe(
      (res:any)=>{
        console.log("success");
        this.toastr.success("Record Inserted Successfully","Employees Registration");
        this.emitSavedData.emit(res);
        this.LoadAllEmployees();
      },
      err=>{
        console.log("failed");
        this.toastr.warning("Record Insert Failed","Employees Registration");
        console.log(err);
      }
    )
  }

  UpdateEmployees(){
    this.employees_service.updateEmployees().subscribe(
      (res:any)=>{
        this.toastr.info("Record Updated Successfully", "Employee Registration");
        this.LoadAllEmployees();
      },
      err=>{
        this.toastr.warning("Record Update Failed","Employees Registration");
        console.log(err);
      }
    )
  }

  populateForm(employee:Employees){
    this.employees_service.formData = Object.assign({},employee);
  }

  DeleteEmployee(Id){
    console.log(Id);
    if(confirm('Are you sure?'))
    this.employees_service.deleteEmployee(Id).subscribe(
      (res:any)=>{
        this.toastr.success("Record Deleted Successfully", "Employee Registration");
        this.LoadAllEmployees();
      },
      err=>{
        this.toastr.warning("Record Delete Failed","Employees Registration");
        console.log(err);
      }
    )
  }

}

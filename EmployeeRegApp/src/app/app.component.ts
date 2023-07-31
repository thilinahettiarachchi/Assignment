import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'EmployeeApp';
  title2 = 'Employee Details';
  showSubTitle : boolean = true;
  getSavedData(response){
    let test = response;
  };
}

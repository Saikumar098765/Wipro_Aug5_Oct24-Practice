import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})

export class EmployeeComponent {
  @Input() employee: any; // Accept employee data as input
  showDetails() {
    alert('Showing details for ' + this.employee.name);
  }
}



  
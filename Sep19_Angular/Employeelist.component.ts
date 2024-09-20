import { Component } from '@angular/core';

@Component({
  selector: 'app-employee-list',
  templateUrl: './Employeelist.component.html',
 // styleUrls: ['./Employee-list.component.css']
})
export class EmployeeListComponent {
  employees = [
    { name: 'John Doe', position: 'Software Engineer', department: 'IT' },
    { name: 'Jane Smith', position: 'Product Manager', department: 'Sales' },
    { name: 'Bob Johnson', position: 'Designer', department: 'Marketing' }
  ];
}

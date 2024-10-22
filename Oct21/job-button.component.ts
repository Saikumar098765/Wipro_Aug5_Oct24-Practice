import { Component } from '@angular/core';

@Component({
  selector: 'app-job-button',
  standalone: true,
  template: `
    <button (click)="setJob()">Set Job</button>
  `,
  styles: [`
    button {
      padding: 10px 20px;
      font-size: 16px;
      background-color: #4CAF50;
      color: white;
      border: none;
      border-radius: 5px;
      cursor: pointer;
    }
    button:hover {
      background-color: #45a049;
    }
  `]
})
export class JobButtonComponent {
  setJob() {
    console.log('Job set!');
    // You can add more functionality here
  }
}
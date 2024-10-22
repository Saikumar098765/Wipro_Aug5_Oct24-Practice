import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="user-profile" *ngIf="user">
      <h2>User Profile</h2>
      <div class="profile-section">
        <label>Name:</label>
        <input [(ngModel)]="user.name" placeholder="Your Name">
      </div>
      <div class="profile-section">
        <label>Email:</label>
        <input [(ngModel)]="user.email" placeholder="Your Email" type="email">
      </div>
      <div class="profile-section">
        <label>Skills:</label>
        <input [(ngModel)]="skillInput" (keyup.enter)="addSkill()" placeholder="Add a skill">
        <ul class="skills-list">
          <li *ngFor="let skill of user.skills; let i = index">
            {{ skill }}
            <button (click)="removeSkill(i)" class="remove-skill">×</button>
          </li>
        </ul>
      </div>
      <button (click)="updateProfile()" class="update-btn">Update Profile</button>
    </div>
  `,
  styles: [`
    .user-profile {
      max-width: 600px;
      margin: 0 auto;
      padding: 20px;
      background-color: #f9f9f9;
      border-radius: 8px;
      box-shadow: 0 2px 4px rgba(0,0,0,0.1);
    }
    .profile-section {
      margin-bottom: 20px;
    }
    label {
      display: block;
      margin-bottom: 5px;
      font-weight: bold;
    }
    input {
      width: 100%;
      padding: 8px;
      font-size: 16px;
      border: 1px solid #ddd;
      border-radius: 4px;
    }
    .skills-list {
      list-style-type: none;
      padding: 0;
    }
    .skills-list li {
      background-color: #e7f3ff;
      display: inline-block;
      margin: 5px;
      padding: 5px 10px;
      border-radius: 3px;
    }
    .remove-skill {
      background: none;
      border: none;
      color: red;
      cursor: pointer;
      font-weight: bold;
      margin-left: 5px;
    }
    .update-btn {
      background-color: #1976d2;
      color: white;
      padding: 10px 20px;
      font-size: 18px;
      border: none;
      border-radius: 5px;
      cursor: pointer;
      transition: background-color 0.3s;
    }
    .update-btn:hover {
      background-color: #1565c0;
    }
  `]
})
export class UserProfileComponent implements OnInit {
  user: any;
  skillInput: string = '';

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.getCurrentUser().subscribe(
      (data) => this.user = data,
      (error) => console.error('Error fetching user profile:', error)
    );
  }

  addSkill() {
    if (this.skillInput.trim() && !this.user.skills.includes(this.skillInput.trim())) {
      this.user.skills.push(this.skillInput.trim());
      this.skillInput = '';
    }
  }

  removeSkill(index: number) {
    this.user.skills.splice(index, 1);
  }

  updateProfile() {
    this.userService.updateUser(this.user).subscribe(
      () => alert('Profile updated successfully!'),
      (error) => console.error('Error updating profile:', error)
    );
  }
}

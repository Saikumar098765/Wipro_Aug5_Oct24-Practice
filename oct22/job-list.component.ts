import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { JobService } from '../../services/job.service';

@Component({
  selector: 'app-job-list',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  template: `
    <h2>Job Listings</h2>
    <div class="search-bar">
      <input [(ngModel)]="searchTerm" (input)="searchJobs()" placeholder="Search jobs...">
    </div>
    <ul class="job-list">
      <li *ngFor="let job of filteredJobs" class="job-item">
        <a [routerLink]="['/jobs', job.id]" class="job-link">
          <h3>{{ job.title }}</h3>
          <p>{{ job.company }}</p>
          <p>{{ job.location }}</p>
          <p class="salary">{{ job.salary | currency:'USD':'symbol':'1.0-0' }}/year</p>
        </a>
      </li>
    </ul>
  `,
  styles: [`
    .search-bar {
      margin-bottom: 20px;
    }
    .search-bar input {
      width: 100%;
      padding: 10px;
      font-size: 16px;
    }
    .job-list {
      list-style-type: none;
      padding: 0;
    }
    .job-item {
      border: 1px solid #ddd;
      margin-bottom: 10px;
      padding: 15px;
      border-radius: 5px;
      transition: background-color 0.3s;
    }
    .job-item:hover {
      background-color: #f5f5f5;
    }
    .job-link {
      text-decoration: none;
      color: inherit;
    }
    .job-link h3 {
      margin: 0 0 10px 0;
      color: #1976d2;
    }
    .salary {
      font-weight: bold;
      color: #4CAF50;
    }
  `]
})
export class JobListComponent implements OnInit {
  jobs: any[] = [];
  filteredJobs: any[] = [];
  searchTerm: string = '';

  constructor(private jobService: JobService) {}

  ngOnInit() {
    this.jobService.getJobs().subscribe(
      (data) => {
        this.jobs = data;
        this.filteredJobs = data;
      },
      (error) => console.error('Error fetching jobs:', error)
    );
  }

  searchJobs() {
    this.filteredJobs = this.jobs.filter(job =>
      job.title.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      job.company.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      job.location.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
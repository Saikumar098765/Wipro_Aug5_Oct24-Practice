import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { JobService } from '../../services/job.service';

@Component({
  selector: 'app-job-detail',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div *ngIf="job" class="job-detail">
      <h2>{{ job.title }}</h2>
      <p class="company">{{ job.company }}</p>
      <p class="location">{{ job.location }}</p>
      <p class="salary">{{ job.salary | currency:'USD':'symbol':'1.0-0' }}/year</p>
      <h3>Job Description</h3>
      <p>{{ job.description }}</p>
      <h3>Required Skills</h3>
      <ul>
        <li *ngFor="let skill of job.requiredSkills">{{ skill }}</li>
      </ul>
      <button (click)="applyForJob()" class="apply-btn">Apply Now</button>
    </div>
  `,
  styles: [`
    .job-detail {
      max-width: 800px;
      margin: 0 auto;
      padding: 20px;
      background-color: #f9f9f9;
      border-radius: 8px;
      box-shadow: 0 2px 4px rgba(0,0,0,0.1);
    }
    h2 {
      color: #1976d2;
      margin-bottom: 10px;
    }
    .company, .location {
      font-size: 18px;
      color: #555;
    }
    .salary {
      font-size: 20px;
      font-weight: bold;
      color: #4CAF50;
      margin-bottom: 20px;
    }
    h3 {
      margin-top: 20px;
      color: #333;
    }
    ul {
      list-style-type: none;
      padding: 0;
    }
    li {
      background-color: #e7f3ff;
      margin: 5px 0;
      padding: 5px 10px;
      border-radius: 3px;
      display: inline-block;
      margin-right: 10px;
    }
    .apply-btn {
      background-color: #4CAF50;
      color: white;
      padding: 10px 20px;
      font-size: 18px;
      border: none;
      border-radius: 5px;
      cursor: pointer;
      transition: background-color 0.3s;
      margin-top: 20px;
    }
    .apply-btn:hover {
      background-color: #45a049;
    }
  `]
})
export class JobDetailComponent implements OnInit {
  job: any;

  constructor(
    private route: ActivatedRoute,
    private jobService: JobService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    
    // Handle case when 'id' is null
    if (id) {
      this.jobService.getJob(id).subscribe(
        (data) => this.job = data,
        (error) => console.error('Error fetching job details:', error)
      );
    } else {
      console.error('Job ID is null');
    }
  }

  applyForJob() {
    console.log('Applying for job:', this.job.id);
    alert('Application submitted successfully!');
  }
}

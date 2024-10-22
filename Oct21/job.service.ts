import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private apiUrl = 'https://fake-json-api.mock.beeceptor.com/users'; // Replace with your actual API URL

  // Mocked job data
  private mockJobs = [
    { id: '1', title: 'Software Engineer', company: 'Tech Co', location: 'San Francisco, CA', salary: 120000, description: 'Exciting opportunity for a skilled software engineer...', requiredSkills: ['JavaScript', 'React', 'Node.js'] },
    { id: '2', title: 'Data Scientist', company: 'Data Corp', location: 'New York, NY', salary: 130000, description: 'Join our data science team to solve complex problems...', requiredSkills: ['Python', 'Machine Learning', 'SQL'] },
    { id: '3', title: 'UX Designer', company: 'Design Studio', location: 'Los Angeles, CA', salary: 95000, description: 'Create beautiful and intuitive user experiences...', requiredSkills: ['UI/UX Design', 'Figma', 'User Research'] },
  ];

  constructor(private http: HttpClient) {}

  getJobs(): Observable<any[]> {
    // For demo purposes, return mock data
    return of(this.mockJobs);
    // In a real application, you would use:
    // return this.http.get<any[]>(this.apiUrl);
  }

  getJob(id: string): Observable<any> {
    // For demo purposes, find and return a mock job
    const job = this.mockJobs.find(j => j.id === id);
    return of(job);
    // In a real application, you would use:
    // return this.http.get<any>(`${this.apiUrl}/${id}`);
  }
}
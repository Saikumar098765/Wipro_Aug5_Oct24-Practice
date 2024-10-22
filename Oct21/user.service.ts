import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://api.example.com/users'; // Replace with your actual API URL

  // Mocked user data
  private mockUser = {
    id: '1',
    name: 'John Doe',
    email: 'john@example.com',
    skills: ['JavaScript', 'React', 'Node.js']
  };

  constructor(private http: HttpClient) {}

  getCurrentUser(): Observable<any> {
    // For demo purposes, return mock data
    return of(this.mockUser);
    // In a real application, you would use:
    // return this.http.get<any>(`${this.apiUrl}/current`);
  }

  updateUser(user: any): Observable<any> {
    // For demo purposes, just return the updated user
    this.mockUser = { ...this.mockUser, ...user };
    return of(this.mockUser);
    // In a real application, you would use:
    // return this.http.put<any>(`${this.apiUrl}/${user.id}`, user);
  }
}
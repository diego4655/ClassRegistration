import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Student } from '../Interfaces/student';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = '/api';  // This will be proxied to the backend

  constructor(private http: HttpClient) { }

  //#region Courses
  getCourses(): Observable<any> {
    return this.http.get(`${this.apiUrl}/courses`, {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    });
  }
  //#endregion
  
  //#region Students
  createStudent(student: string): Observable<any> {
    let studentObject: Student = {
      name: student
    };
    return this.http.post(`${this.apiUrl}/student`, studentObject, {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    });
  }


  getStudents(): Observable<any> {
    return this.http.get(`${this.apiUrl}/student`, {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    });
  }
  //#endregion

  getTeachers(): Observable<any> {
    return this.http.get(`${this.apiUrl}/Teachers`, {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    });
  }

 
  // Enrollments
  getEnrollments(): Observable<any> {
    return this.http.get(`${this.apiUrl}/Enrollments`, {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    });
  }
} 

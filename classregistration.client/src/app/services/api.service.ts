import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, Observable } from 'rxjs';
import { Student } from '../Interfaces/student';
import { Course } from '../Interfaces/course';
import { StudentCourse, StudentCourseResponse, StudentPartnerResponse } from '../Interfaces/studentCouses';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = '/api';  // This will be proxied to the backend

  constructor(private http: HttpClient) { }

  //#region Courses
  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(`${this.apiUrl}/courses`, {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    });
  }

  registerClass(studentCourse: StudentCourse): Observable<any> {
    return this.http.post(`${this.apiUrl}/studentCourses`, JSON.stringify(studentCourse), {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    });
  }

  getStudentCourses(studentId: string): Observable<StudentCourseResponse> {
    return this.http.get<StudentCourseResponse>(`${this.apiUrl}/studentCourses/AllCourseByStudent?studentId=${studentId}`, {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    }).pipe(
      catchError((error: any) => {
        throw new Error(error);
      })
    );
  }

  getStudentParners(studentId: string): Observable<StudentPartnerResponse> {
    return this.http.get<StudentPartnerResponse>(`${this.apiUrl}/studentCourses/AllStudentparners?studentId=${studentId}`, {
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
      id: '',
      name: student
    };
    return this.http.post(`${this.apiUrl}/student`, studentObject, {
      headers: new HttpHeaders({
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      })
    });
  }

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.apiUrl}/student`, {
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

  deleteStudentCourse(courseId: string, studentId: string) {
    return this.http.delete(`${this.apiUrl}/StudentCourses?courseId=${courseId}&studentId=${studentId}`);
  }
} 

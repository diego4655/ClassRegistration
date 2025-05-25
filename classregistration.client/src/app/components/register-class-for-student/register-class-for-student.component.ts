import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Student } from '../../Interfaces/student';
import { ApiService } from '../../services/api.service';
import { Course } from '../../Interfaces/course';

@Component({
  selector: 'app-register-class-for-student',
  templateUrl: './register-class-for-student.component.html',
  styleUrl: './register-class-for-student.component.css'
})
export class RegisterClassForStudentComponent {
  students: Student[] = [];
  selectedStudent: Student | null = null;
  courses: Course[] = [];
  selectedCourse: Course | null = null;


  constructor(private router: Router, private apiService: ApiService) {
  }


  ngOnInit() {
    this.apiService.getStudents().subscribe(students => {
      this.students = students;
    });
    this.apiService.getCourses().subscribe(courses => {
      this.courses = courses;
    });
  }

  navigateToMainview() {
    this.router.navigate(['']);
  }
}

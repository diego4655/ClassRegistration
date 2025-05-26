import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Student } from '../../Interfaces/student';
import { ApiService } from '../../services/api.service';
import { Course } from '../../Interfaces/course';
import { StudentCourse, StudentPartnerResponse } from '../../Interfaces/studentCouses';
import Swal from 'sweetalert2';

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
  studentPartners: StudentPartnerResponse = {
    studentId: '',
    students: []
  };


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

  onStudentChange(event: any) {
    console.log(event.value);
    this.apiService.getStudentParners(event.value.id).subscribe(studentPartners => {
      this.studentPartners = studentPartners;
      console.log(this.studentPartners);
    });
  }

  navigateToMainview() {
    this.router.navigate(['']);
  }

  registerClass() {
    if (this.selectedStudent && this.selectedCourse) {
      let studentCourse: StudentCourse = {
        studentId: this.selectedStudent.id,
        courseId: this.selectedCourse.id
      };
      this.apiService.registerClass(studentCourse).subscribe({        
          error: (error: any) => Swal.fire(error.error.detail),
          complete: () => Swal.fire('Clase registrada correctamente'),          
      });
    }
  }
}

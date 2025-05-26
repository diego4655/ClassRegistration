import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Student } from '../../Interfaces/student';
import { StudentCourseResponse } from '../../Interfaces/studentCouses';
import Swal from 'sweetalert2';
import { Course } from '../../Interfaces/course';
import { Router } from '@angular/router';

@Component({
  selector: 'app-look-student-courses',
  templateUrl: './look-student-courses.component.html',
  styleUrl: './look-student-courses.component.css'
})
export class LookStudentCoursesComponent {
  students: Student[] = [];
  selectedStudent!: Student;
  studentCourses: StudentCourseResponse = {
    student: {
      id: '',
      name: '',
      credits: 0
    },
    courses: []
  };

  constructor(private apiService: ApiService, private router: Router) {}

  ngOnInit() {
    this.getStudent();
  }

  getStudent(){
    this.apiService.getStudents().subscribe(students => {
      this.students = students;
    });
  }

  getStudentCourses(){
    if (!this.selectedStudent) {
      Swal.fire('Error', 'Por favor seleccione un estudiante', 'error');
      return;
    }
    
    this.apiService.getStudentCourses(this.selectedStudent.id).subscribe({
      next: (studentCourses) => {
        console.log(studentCourses);
        this.studentCourses = studentCourses;
      },
      error: (error) => {
        Swal.fire('Error', error.message || 'Error al obtener los cursos', 'error');
      }
    });
  }

  navigateToMainview() {
    this.router.navigate(['']);
  }


  deleteCourse(courseId: string, studentId: string) {
    Swal.fire({
      title: '¿Está seguro?',
      text: "Esta acción no se puede revertir",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sí, eliminar',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.apiService.deleteStudentCourse(courseId, studentId).subscribe({
          next: () => {
            Swal.fire('Eliminado', 'La matrícula ha sido eliminada', 'success');
            this.getStudentCourses();
          },
          error: (error) => {
            Swal.fire('Error', error.message || 'Error al eliminar la matrícula', 'error');
          }
        });
      }
    });
  }
}

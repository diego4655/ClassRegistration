import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterStudentComponent } from './components/register-student/register-student.component';
import { RegisterClassForStudentComponent } from './components/register-class-for-student/register-class-for-student.component';
import { LookStudentCoursesComponent } from './components/look-student-courses/look-student-courses.component';
import { MainviewComponent } from './components/mainview/mainview.component';

const routes: Routes = [
  {
    path: '',
    component: MainviewComponent
  },
  {
    path: 'register-student',
    component: RegisterStudentComponent
  },
  {
    path: 'register-class-for-student',
    component: RegisterClassForStudentComponent
  },
  {
    path: 'look-student-courses',
    component: LookStudentCoursesComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

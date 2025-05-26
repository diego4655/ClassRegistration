import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonModule } from 'primeng/button';
import { RegisterStudentComponent } from './components/register-student/register-student.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RegisterClassForStudentComponent } from './components/register-class-for-student/register-class-for-student.component';
import { CardModule } from 'primeng/card';
import { MainviewComponent } from './components/mainview/mainview.component';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabelModule } from 'primeng/floatlabel';
import { DropdownModule } from 'primeng/dropdown';
import { LookStudentCoursesComponent } from './components/look-student-courses/look-student-courses.component';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,    
    RegisterStudentComponent,
    RegisterClassForStudentComponent,
    MainviewComponent,
    LookStudentCoursesComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    ButtonModule,
    ReactiveFormsModule,
    FormsModule,
    CardModule,
    InputTextModule,
    FloatLabelModule,
    DropdownModule,
    TableModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

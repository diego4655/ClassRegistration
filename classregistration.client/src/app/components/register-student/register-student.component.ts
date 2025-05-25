import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-student',
  templateUrl: './register-student.component.html',
  styleUrl: './register-student.component.css'
})
export class RegisterStudentComponent {    
  value: string = '';

  constructor(private formBuilder: FormBuilder,
    private apiservice: ApiService,
    private router: Router
  ) {
    
  }

  ngOnInit() {
    this.apiservice.getStudents().subscribe(result => {
      console.log(result);
    });
  }

  

  navigateToMainview() {
    this.router.navigate(['']);
  }

  onSubmit() {
    this.apiservice.createStudent(this.value).subscribe(result => {
      console.log(result);
      this.navigateToMainview();
    });
  }
}

import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mainview',
  templateUrl: './mainview.component.html',
  styleUrl: './mainview.component.css'
})

export class MainviewComponent {  
  constructor(private router: Router) {}
  
  navigateToRegisterStudent() {
    this.router.navigate(['/register-student']);
  }

  navigateToRegisterClassForStudent() {
    this.router.navigate(['/register-class-for-student']);
  }
}

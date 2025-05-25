import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterClassForStudentComponent } from './register-class-for-student.component';

describe('RegisterClassForStudentComponent', () => {
  let component: RegisterClassForStudentComponent;
  let fixture: ComponentFixture<RegisterClassForStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegisterClassForStudentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterClassForStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

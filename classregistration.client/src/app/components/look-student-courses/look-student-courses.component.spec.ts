import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LookStudentCoursesComponent } from './look-student-courses.component';

describe('LookStudentCoursesComponent', () => {
  let component: LookStudentCoursesComponent;
  let fixture: ComponentFixture<LookStudentCoursesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LookStudentCoursesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LookStudentCoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

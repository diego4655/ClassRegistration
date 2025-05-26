import { Course } from "./course";
import {  Student, StudentResponse } from "./student";

export interface StudentCourse {
    studentId: string;
    courseId: string;
}

export interface StudentCourseResponse {
    student: StudentResponse;
    courses: Course[];
}

export interface StudentPartnerResponse {
    studentId: string;
    students: StudentByClass[];
}

export interface StudentByClass{    
    courseName: string;
    studentList: Student[];
}
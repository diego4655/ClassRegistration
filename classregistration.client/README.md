# Cliente - Sistema de Registro de Clases

## Requisitos Previos
- Node.js (versión 18 o superior)
- npm (incluido con Node.js)
- Angular CLI (versión 16 o superior)

## Instalación

1. Instalar dependencias globales:
```bash
npm install -g @angular/cli
```

2. Instalar dependencias del proyecto:
```bash
npm install
```

## Dependencias Principales
- Angular 16
- PrimeNG (UI Components)
- PrimeIcons
- SweetAlert2 (Notificaciones)
- RxJS

## Estructura del Proyecto
```
src/
├── app/
│   ├── components/
│   │   ├── look-student-courses/
│   │   ├── register-class-for-student/
│   │   └── register-student/
│   ├── interfaces/
│   ├── services/
│   └── app.module.ts
├── assets/
└── environments/
```

## Configuración

 Configurar el proxy para desarrollo:
   - El archivo `proxy.conf.json` está configurado para redirigir las peticiones API al servidor local


## Ejecución del Proyecto

1. Servidor de desarrollo:
```bash
ng serve
```
o arrancar directamente en visual studio
La aplicación estará disponible en `http://localhost:50931`



## Características Implementadas
- Registro de estudiantes
- Registro de clases para estudiantes
- Visualización de clases por estudiante
- Interfaz de usuario moderna con PrimeNG
- Manejo de errores
- Notificaciones con SweetAlert2

## Estructura de Componentes
- `register-student`: Registro de nuevos estudiantes
- `register-class-for-student`: Matrícula de estudiantes en cursos
- `look-student-courses`: Visualización de cursos por estudiante

## Servicios
- `ApiService`: Manejo de todas las peticiones HTTP al backend
- Implementación de interceptores para manejo de errores
- Manejo de respuestas y errores HTTP

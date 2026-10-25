# U6A1 - Implementación de Algoritmos de Búsqueda y Optimización

Actividad correspondiente a la Unidad 6 de la materia **Análisis y Diseño de Algoritmos**.

Este repositorio contiene dos implementaciones desarrolladas en C#:

1. Resolución de Sudoku mediante Backtracking.
2. Resolución del Problema de la Mochila mediante Ramificación y Poda (Branch and Bound).

---

## Estructura del repositorio

```text
U6A1
│
├── sudoku
│   └── Proyecto de resolución de Sudoku
│
├── ramificacionYPoda
│   └── Proyecto del Problema de la Mochila
│
└── .gitignore
```

---

# Proyecto 1: Sudoku mediante Backtracking

## Descripción

Se desarrolló un algoritmo para resolver tableros Sudoku utilizando la técnica de **Backtracking**.

El algoritmo busca casillas vacías, intenta asignar valores válidos y retrocede cuando detecta que una decisión no puede conducir a una solución correcta.

## Funcionalidades

- Resolver el Sudoku proporcionado en la actividad.
- Resolver dos Sudokus de prueba adicionales.
- Capturar un Sudoku manualmente.
- Mostrar estadísticas de ejecución.
- Medir tiempo de procesamiento.

## Métricas registradas

- Intentos realizados.
- Retrocesos (Backtracking).
- Tiempo de ejecución.

## Complejidad

Peor caso:

```text
O(9^n)
```

Donde: n = cantidad de casillas vacías.

---

# Proyecto 2: Problema de la Mochila mediante Ramificación y Poda

## Descripción

Se desarrolló una implementación del problema clásico de la mochila utilizando la técnica de **Ramificación y Poda (Branch and Bound)**.

El algoritmo genera posibles soluciones mediante un árbol de decisiones y elimina ramas que no cumplen las restricciones de capacidad.

## Funcionalidades

- Resolver el ejemplo proporcionado en la actividad.
- Definir la capacidad de la mochila.
- Capturar objetos personalizados.
- Mostrar la mejor solución encontrada.
- Mostrar estadísticas de ejecución.

## Métricas registradas

- Nodos generados.
- Ramas podadas.
- Tiempo de ejecución.
- Valor total obtenido.
- Peso total utilizado.

## Complejidad

Peor caso:

```text
O(2^n)
```

Donde: n = cantidad de objetos disponibles.

---

# Requisitos

- .NET 8.0 o superior
- Visual Studio 2022 o superior

También puede ejecutarse utilizando la CLI de .NET.

---

# Ejecución

## Sudoku

```bash
cd sudoku
dotnet run
```

## Ramificación y Poda

```bash
cd ramificacionYPoda
dotnet run
```

---

# Objetivos de Aprendizaje

Con estos proyectos se busca aplicar conceptos relacionados con:

- Diseño y análisis de algoritmos.
- Búsqueda en espacios de estados.
- Backtracking.
- Ramificación y poda.
- Optimización combinatoria.
- Evaluación experimental de algoritmos.

---

# Autor

**Luis Gerardo Aguirre Cervantes**

Maestría en Sistemas  
Universidad Autónoma de Guadalajara

---

# Licencia

Proyecto desarrollado con fines académicos.

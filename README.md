# Instrucciones y reglas Git

Antes de realizar un push, asegurarse de hacer pull de
la rama Develop.

Por favor no modificar este archivo.

## Ramas
- Develop
- MondayGroup
- TuesdayGroup
- Content
- UX/UI

Cada característica o corrección de errores se desarrolla en su propia rama (Grupo al que pertenece). Una vez completada y probada, se fusiona con la rama principal (Desarrollo).

Los integrantes de UX/UI no deberán publicar nada en MondayGroup o TuesdayGroup

## BackUp
- Cada Domingo a las 17:00 h los arquitectos de infraestructura realizarán un backup de la rama de desarrollo en sus dispositivos locales.

## Commits
- Cada vez que desee realizar un commit, asegúrese de no tener ningún error en el código.
- Realice commits únicamente necesarios, es decir, no realizar muchos commits con pequeños cambios, sino un commit que incluya cambios importantes.
- Cada commit debe tener una descripción detallada de las nuevas características a subir o errores que se corrigieron.

## Rebase
Es una estrategia para combinar el trabajo de diferentes ramas. En lugar de combinar las ramas, "rebase" toma todos los cambios en una rama y los aplica en la otra rama.

## 3-way merge
Si las dos ramas que se están fusionando y la base común más reciente de las ramas tienen cambios, Git realizará una fusión de tres vías. Utiliza los cambios en las dos ramas y la base común para determinar cómo fusionar.

## Estrategia ramificación
Cada uno puede publicar cambios de características o errores que se encuentre solucionando en una nueva rama propia en la que almacenará su avance antes de hacer el push en la rama del grupo.
- Nomenclatura para crear la rama: 
En caso de ser una funcionalidad:
feature_"sprint"_"functionalityName"
Em caso de ser un error o bug:
fix_"sprint"_nameBug

## Por favor seguir las instrucciones
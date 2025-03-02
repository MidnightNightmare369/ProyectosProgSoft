Comandos de git: 
Ramas: crear -> branch <nombreRama> 
Eliminar -> branch -d <nombreRama>
moverse por ramas:
mover HEAD-> checkout 
mover MAIN-> reset --hard 
Crear RAMA-> branch
Moverse a una rama -> switch <nombre>
Cambios temporales -> stash /recuperar -> stash pop
eliminar -> stash drop / ver lista -> stash list 

crear archivo -> touch borrar -> rm -diferencias ->diff stas
Alias: 
crear git config --global alias.<nombre> "argumentos"
existentes git config --global --get-regexp alias
borrar git config --global --unset alias.<nombre>
Tags: git tag <nombre>


crear un .gitignore y dentro de el colocar **/.<nombre> los asteriscos significan que da igual donde este el .<nombre>

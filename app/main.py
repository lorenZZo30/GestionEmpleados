from fastapi import FastAPI
from app.routers import sedes, departamentos, empleados
from app.db.session import engine
from sqlmodel import SQLModel

# ⚠️ Importar todos los modelos para que metadata los conozca
from app.models.sede import Sede
from app.models.departamento import Departamento
from app.models.empleado import Empleado

app = FastAPI()

# Registrar las rutas
app.include_router(sedes.router)
app.include_router(departamentos.router)
app.include_router(empleados.router)

# Crear tablas en la base de datos si no existen
def init_db():
    SQLModel.metadata.create_all(engine)

init_db()
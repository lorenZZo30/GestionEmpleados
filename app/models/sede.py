from typing import List, TYPE_CHECKING
from sqlmodel import SQLModel, Field, Relationship

if TYPE_CHECKING:
    from app.models.departamento import Departamento
    from app.models.empleado import Empleado

class Sede(SQLModel, table=True):
    id: int = Field(default=None, primary_key=True)
    ciudad: str
    direccion: str

    empleados: List["Empleado"] = Relationship(back_populates="sede")

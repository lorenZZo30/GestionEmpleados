from typing import List, Optional, TYPE_CHECKING
from sqlmodel import SQLModel, Field, Relationship

if TYPE_CHECKING:
    from app.models.sede import Sede
    from app.models.empleado import Empleado

class Departamento(SQLModel, table=True):
    id: int | None = Field(default=None, primary_key=True)
    nombre: str

    empleados: List["Empleado"] = Relationship(back_populates="departamento")

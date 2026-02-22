from typing import Optional
from sqlmodel import SQLModel, Field, Relationship

from typing import TYPE_CHECKING
if TYPE_CHECKING:
    from app.models.sede import Sede
    from app.models.departamento import Departamento


class Empleado(SQLModel, table=True):
    id: int | None = Field(default=None, primary_key=True)
    nombre: str
    sede_id: int = Field(foreign_key="sede.id")
    departamento_id: int = Field(foreign_key="departamento.id")

    sede: "Sede" = Relationship(back_populates="empleados")
    departamento: "Departamento" = Relationship(back_populates="empleados")

from sqlmodel import SQLModel

class EmpleadoCreate(SQLModel):
    nombre: str
    sede_id: int
    departamento_id: int

class EmpleadoResponse(EmpleadoCreate):
    id: int

class EmpleadoUpdate(SQLModel):
    nombre: str | None = None
    sede_id: int | None = None
    departamento_id: int | None = None
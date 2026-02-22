from sqlmodel import SQLModel

class SedeCreate(SQLModel):
    ciudad: str
    direccion: str

class SedeResponse(SedeCreate):
    id: int

class SedeUpdate(SQLModel):
    ciudad: str | None = None
    direccion: int | None = None
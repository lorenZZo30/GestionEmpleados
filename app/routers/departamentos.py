from fastapi import APIRouter, Depends
from sqlmodel import Session
from app.db.session import get_session
from app.services.departamento_service import DepartamentoService
from app.schemas.departamento import DepartamentoCreate, DepartamentoResponse, DepartamentoUpdate

router = APIRouter(prefix="/departamentos", tags=["Departamentos"])

@router.post("/", response_model=DepartamentoResponse)
async def create_departamento(autor: DepartamentoCreate, service: DepartamentoService = Depends()):
    return service.create(autor)

@router.get("/", response_model=list[DepartamentoResponse])
async def read_departamentos(service: DepartamentoService = Depends()):
    return service.get_all()

@router.get("/{id}", response_model=DepartamentoResponse)
async def read_departamento(id: int, service: DepartamentoService = Depends()):
    return service.get_by_id(id)

@router.patch("/{id}", response_model=DepartamentoResponse)
async def update_departamento(id: int, autor_data: DepartamentoUpdate, service: DepartamentoService = Depends()):
    return service.update(id, autor_data)

@router.delete("/{id}", response_model=dict)
async def delete_departamento(id: int, service: DepartamentoService = Depends()):
    return service.delete(id)

from fastapi import APIRouter, Depends, Query
from app.services.empleado_service import EmpleadoService
from app.schemas.empleado import EmpleadoCreate, EmpleadoResponse, EmpleadoUpdate

router = APIRouter(prefix="/empleados", tags=["Empleados"])

@router.post("/", response_model=EmpleadoResponse)
async def create_empleado(empleado: EmpleadoCreate, service: EmpleadoService = Depends()):
    return service.create(empleado)

@router.get("/", response_model=list[EmpleadoResponse])
async def read_empleados(service: EmpleadoService = Depends(),
                      departamento_id: int | None = Query(None, description="Filtrar por ID del departamento"),
                      sede_id: int | None = Query(None, description="Filtrar por ID de la sede")):
    return service.get_all(departamento_id, sede_id)

@router.get("/{id}", response_model=EmpleadoResponse)
async def read_empleado(id: int, service: EmpleadoService = Depends()):
    return service.get_by_id(id)

@router.patch("/{id}", response_model=EmpleadoResponse)
async def update_empleado(id: int, empleado_data: EmpleadoUpdate, service: EmpleadoService = Depends()):
    return service.update(id, empleado_data)

@router.delete("/{id}", response_model=dict)
async def delete_empleado(id: int, service: EmpleadoService = Depends()):
    return service.delete(id)

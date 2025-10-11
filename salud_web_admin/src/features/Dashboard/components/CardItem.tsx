// src/features/Dashboard/components/CardItem.tsx

// Definimos explícitamente el tipo de Props para mayor claridad
interface CardItemProps {
  titulo: string;
  color: string;
  imagen: string;
}

// Cambiamos el nombre de la función a PascalCase para componentes
function CardItem({ titulo, color, imagen }: CardItemProps) {
  return (
    <div
      // Aplicación de estilos dinámicos de Tailwind
      className={`bg-white rounded-xl shadow-md justify-center flex flex-col items-center gap-5 
                  hover:shadow-lg hover:scale-105 transition cursor-pointer p-4`} 
    >
      <span className={`font-semibold ${color}`}>{titulo}</span>
      {imagen && (
        <img src={imagen} alt={titulo} className="object-cover rounded-md mb-2" />
      )}
    </div>
  );
}

export default CardItem;
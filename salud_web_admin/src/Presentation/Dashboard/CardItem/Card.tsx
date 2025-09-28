function CardItem({ titulo, color, imagen }: { titulo: string; color: string;  imagen: string }) {
  return (
    <div
      className={`bg-white rounded-xl shadow-md justify-center flex flex-col items-center gap-5 hover:shadow-lg hover:scale-105 transition cursor-pointer`}
    >
      <span className={`font-semibold ${color}`}>{titulo}</span>
      {imagen && (
        <img src={imagen} alt={titulo} className=" object-cover rounded-md mb-2" />
      )}
    </div>
  );
}

export default CardItem;
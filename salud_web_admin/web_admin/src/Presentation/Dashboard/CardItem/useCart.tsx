function CardItem({ titulo, color, icon }: { titulo: string; color: string; icon: string }) {
  return (
    <div
      className={`bg-white rounded-xl shadow-md p-5 flex flex-col items-center gap-2 hover:shadow-lg hover:scale-105 transition cursor-pointer`}
    >
      <span className={`text-3xl ${color}`}>{icon}</span>
      <span className={`font-semibold ${color}`}>{titulo}</span>
    </div>
  );
}

export default CardItem;
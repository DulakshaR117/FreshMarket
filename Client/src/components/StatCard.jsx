function StatCard({ number, title }) {
  return (
    <div className="text-center">

      <h2 className="text-5xl font-extrabold text-white">
        {number}
      </h2>

      <p className="mt-4 text-green-100">
        {title}
      </p>

    </div>
  );
}

export default StatCard;
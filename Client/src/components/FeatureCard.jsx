function FeatureCard({
  icon,
  title,
  description,
}) {
  return (
    <div className="group bg-white rounded-3xl p-8 shadow-sm border border-gray-100 hover:shadow-xl hover:-translate-y-2 transition-all duration-300">

      <div className="w-16 h-16 rounded-2xl bg-green-100 flex items-center justify-center text-3xl mb-6 group-hover:scale-110 transition">
        {icon}
      </div>

      <h3 className="text-2xl font-bold mb-3">
        {title}
      </h3>

      <p className="text-gray-600 leading-7">
        {description}
      </p>

    </div>
  );
}

export default FeatureCard;
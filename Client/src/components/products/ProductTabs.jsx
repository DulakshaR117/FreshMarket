function ProductTabs() {
  return (
    <section className="py-20 bg-white">

      <div className="max-w-5xl mx-auto px-6">

        <div className="flex gap-8 border-b pb-5">

          <button className="font-semibold text-green-600 border-b-2 border-green-600 pb-3">
            Description
          </button>

          <button className="text-gray-500">
            Nutrition
          </button>

          <button className="text-gray-500">
            Shipping
          </button>

        </div>

        <div className="mt-10 text-gray-600 leading-8">

          <p>
            Our organic carrots are harvested fresh every morning from trusted
            local farms across Sri Lanka. They are naturally rich in Vitamin A,
            antioxidants and dietary fiber.
          </p>

          <br />

          <p>
            Perfect for soups, salads, juices and healthy family meals.
          </p>

        </div>

      </div>

    </section>
  );
}

export default ProductTabs;



import FeaturedProducts from "../components/home/FeaturedProducts";
import Newsletter from "../components/Newsletter";
import StatCard from "../components/StatCard";
import FeatureCard from "../components/FeatureCard";

import { Link } from "react-router-dom";
import {
  FiArrowRight,
  FiTruck,
  FiShield,
} from "react-icons/fi";

import { LuLeaf } from "react-icons/lu";

function Home() {
  return (
    <>
      {/* HERO */}
      <section className="bg-gradient-to-br from-green-50 via-white to-green-100">
        <div className="max-w-7xl mx-auto px-6 py-24">
          <div className="grid lg:grid-cols-2 gap-16 items-center">
            {/* LEFT */}
            <div>
              <span className="inline-flex items-center bg-green-100 text-green-700 px-4 py-2 rounded-full text-sm font-semibold mb-6">
                🌱 100% Fresh From Local Farmers
              </span>

              <h1 className="text-5xl lg:text-7xl font-extrabold leading-tight text-gray-900">
                Fresh Food
                <br />
                Delivered
                <span className="text-green-600"> Daily.</span>
              </h1>

              <p className="mt-8 text-lg text-gray-600 leading-8 max-w-xl">
                Shop premium vegetables, fruits, dairy products and groceries
                delivered directly from trusted local farms to your doorstep.
              </p>

              <div className="flex gap-4 mt-10">
                <Link
                  to="/products"
                  className="bg-green-600 hover:bg-green-700 text-white px-8 py-4 rounded-full font-semibold transition flex items-center gap-2"
                >
                  Shop Now
                  <FiArrowRight />
                </Link>

                <Link
                  to="/products"
                  className="border-2 border-green-600 text-green-600 hover:bg-green-600 hover:text-white px-8 py-4 rounded-full font-semibold transition"
                >
                  Explore Products
                </Link>
              </div>

              {/* FEATURES */}

              <div className="grid grid-cols-3 gap-6 mt-16">
                <div className="flex items-center gap-3">
                  <FiTruck className="text-green-600 text-2xl" />
                  <div>
                    <p className="font-semibold">Fast</p>
                    <small className="text-gray-500">Delivery</small>
                  </div>
                </div>

                <div className="flex items-center gap-3">
                  <LuLeaf className="text-green-600 text-2xl" />
                  <div>
                    <p className="font-semibold">Organic</p>
                    <small className="text-gray-500">Products</small>
                  </div>
                </div>

                <div className="flex items-center gap-3">
                  <FiShield className="text-green-600 text-2xl" />
                  <div>
                    <p className="font-semibold">Secure</p>
                    <small className="text-gray-500">Payments</small>
                  </div>
                </div>
              </div>
            </div>

            {/* RIGHT */}

            <div className="flex justify-center">
              <div className="text-[220px] lg:text-[320px] select-none">
                🥕
              </div>
            </div>
          </div>
        </div>
      </section>

      

      {/* CATEGORIES */}

      <section className="py-24 bg-white">
        <div className="max-w-7xl mx-auto px-6">
          <div className="text-center">
            <p className="text-green-600 font-semibold uppercase tracking-widest">
              Categories
            </p>

            <h2 className="text-5xl font-bold mt-3">
              Shop By Category
            </h2>

            <p className="text-gray-500 mt-5 max-w-2xl mx-auto">
              Discover fresh products across a variety of categories,
              sourced daily from trusted local farmers.
            </p>
          </div>

          <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-6 gap-8 mt-16">
            <CategoryCard
              emoji="🥦"
              title="Vegetables"
              count="120+"
            />

            <CategoryCard
              emoji="🍎"
              title="Fruits"
              count="85+"
            />

            <CategoryCard
              emoji="🥛"
              title="Dairy"
              count="55+"
            />

            <CategoryCard
              emoji="🥩"
              title="Meat"
              count="40+"
            />

            <CategoryCard
              emoji="🍞"
              title="Bakery"
              count="35+"
            />

            <CategoryCard
              emoji="🥤"
              title="Drinks"
              count="60+"
            />
          </div>
        </div>
      </section>

      
{/* WHY CHOOSE US */}

<section className="py-24 bg-white">

  <div className="max-w-7xl mx-auto px-6">

    <div className="text-center mb-16">

      <p className="text-green-600 uppercase tracking-widest font-semibold">
        Why Choose Us
      </p>

      <h2 className="text-5xl font-bold mt-3">
        Shopping Made Better
      </h2>

      <p className="text-gray-500 mt-5 max-w-2xl mx-auto">
        We deliver premium groceries with speed, freshness and reliability,
        making everyday shopping easier for your family.
      </p>

    </div>

    <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-8">

      <FeatureCard
        icon="🚚"
        title="Fast Delivery"
        description="Get your groceries delivered to your doorstep within hours."
      />

      <FeatureCard
        icon="🌿"
        title="Farm Fresh"
        description="Directly sourced from trusted local farmers every morning."
      />

      <FeatureCard
        icon="🛡"
        title="Secure Payments"
        description="Safe online payments with multiple trusted payment methods."
      />

      <FeatureCard
        icon="⭐"
        title="Premium Quality"
        description="Only the freshest fruits and vegetables make it to your basket."
      />

    </div>

  </div>

</section>
{/* STATS */}

<section className="py-24 bg-green-600 text-white">

  <div className="max-w-7xl mx-auto px-6">

    <div className="grid grid-cols-2 lg:grid-cols-4 gap-10">

      <StatCard
        number="10K+"
        title="Happy Customers"
      />

      <StatCard
        number="500+"
        title="Fresh Products"
      />

      <StatCard
        number="50+"
        title="Local Farmers"
      />

      <StatCard
        number="99%"
        title="Customer Satisfaction"
      />

    </div>

  </div>

</section>

<Newsletter />

<FeaturedProducts />


    </>
  );
}

function CategoryCard({ emoji, title, count }) {
  return (
    <div
      className="
        bg-white
        rounded-3xl
        p-8
        text-center
        shadow-md
        hover:shadow-2xl
        hover:-translate-y-3
        transition-all
        duration-300
        cursor-pointer
        border
        border-gray-100
      "
    >
      <div className="text-6xl">
        {emoji}
      </div>

      <h3 className="font-bold text-xl mt-5">
        {title}
      </h3>

      <p className="text-gray-500 mt-2">
        {count} Products
      </p>
    </div>
  );
}

export default Home;
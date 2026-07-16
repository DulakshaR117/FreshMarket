import { Link } from "react-router-dom";
import {
  FiMapPin,
  FiMail,
  FiPhone,
} from "react-icons/fi";

function Footer() {
  return (
    <footer className="bg-gray-900 text-gray-300">

      <div className="max-w-7xl mx-auto px-6 py-16">

        <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-12">

          {/* Brand */}

          <div>

            <h2 className="text-3xl font-bold text-green-500">
              🌱 FreshMarket
            </h2>

            <p className="mt-5 text-gray-400 leading-7">
              Bringing farm fresh vegetables, fruits and groceries
              directly to your doorstep with quality and care.
            </p>

          </div>

          {/* Quick Links */}

          <div>

            <h3 className="text-xl font-semibold text-white mb-5">
              Quick Links
            </h3>

            <div className="space-y-3">

              <Link
                to="/"
                className="block hover:text-green-400 transition"
              >
                Home
              </Link>

              <Link
                to="/products"
                className="block hover:text-green-400 transition"
              >
                Products
              </Link>

              <Link
                to="/cart"
                className="block hover:text-green-400 transition"
              >
                Cart
              </Link>

              <Link
                to="/login"
                className="block hover:text-green-400 transition"
              >
                Login
              </Link>

            </div>

          </div>

          {/* Categories */}

          <div>

            <h3 className="text-xl font-semibold text-white mb-5">
              Categories
            </h3>

            <div className="space-y-3">

              <p>🥦 Vegetables</p>
              <p>🍎 Fruits</p>
              <p>🥛 Dairy</p>
              <p>🍞 Bakery</p>

            </div>

          </div>

          {/* Contact */}

          <div>

            <h3 className="text-xl font-semibold text-white mb-5">
              Contact
            </h3>

            <div className="space-y-4">

              <div className="flex gap-3">
                <FiMapPin className="text-green-500 mt-1" />
                <span>Colombo, Sri Lanka</span>
              </div>

              <div className="flex gap-3">
                <FiMail className="text-green-500 mt-1" />
                <span>support@freshmarket.com</span>
              </div>

              <div className="flex gap-3">
                <FiPhone className="text-green-500 mt-1" />
                <span>+94 77 123 4567</span>
              </div>

            </div>

          </div>

        </div>

        <div className="border-t border-gray-700 mt-14 pt-8 text-center text-gray-500">

          © 2026 FreshMarket. Built with ❤️ using React & ASP.NET Core.

        </div>

      </div>

    </footer>
  );
}

export default Footer;
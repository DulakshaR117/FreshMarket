import { FiMail, FiSend } from "react-icons/fi";

function Newsletter() {
  return (
    <section className="py-24 bg-white">

      <div className="max-w-4xl mx-auto px-6 text-center">

        <div className="inline-flex items-center justify-center w-20 h-20 rounded-full bg-green-100 text-green-600 text-4xl mb-8">
          <FiMail />
        </div>

        <h2 className="text-5xl font-bold text-gray-900">
          Stay Updated
        </h2>

        <p className="text-gray-600 mt-6 text-lg max-w-2xl mx-auto">
          Subscribe to receive fresh offers, seasonal discounts and the latest
          arrivals delivered directly to your inbox.
        </p>

        <div className="mt-12 flex flex-col md:flex-row gap-4 justify-center">

          <input
            type="email"
            placeholder="Enter your email address"
            className="border border-gray-300 rounded-full px-6 py-4 w-full md:w-96 outline-none focus:border-green-600"
          />

          <button className="bg-green-600 hover:bg-green-700 text-white font-semibold px-8 py-4 rounded-full flex items-center justify-center gap-2 transition">

            Subscribe

            <FiSend />

          </button>

        </div>

      </div>

    </section>
  );
}

export default Newsletter;
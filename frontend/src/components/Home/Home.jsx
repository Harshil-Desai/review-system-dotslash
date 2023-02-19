import { useEffect } from 'react';
import Banner from './Banner/Banner';
import ProductSlider from './ProductSlider/ProductSlider';
import ProductSliderOffers from './ProductSlider/ProductSliderOffers';
import ProductSliderTop from './ProductSlider/ProductSliderTop';
import { useDispatch, useSelector } from 'react-redux';
import { clearErrors, getSliderProducts } from '../../actions/productAction';
import { useSnackbar } from 'notistack';
import MetaData from '../Layouts/MetaData';

const Home = () => {

  const dispatch = useDispatch();
  const { enqueueSnackbar } = useSnackbar();

  const { error, loading } = useSelector((state) => state.products);

  useEffect(() => {
    if (error) {
      enqueueSnackbar(error, { variant: "error" });
      dispatch(clearErrors());
    }
    dispatch(getSliderProducts());
  }, [dispatch, error, enqueueSnackbar]);

  return (
    <>
      <MetaData title="Online Shopping Site for Mobiles, Electronics, Furniture, Grocery, Lifestyle, Books & More. Best Offers!" />

      <main className="flex flex-col justify-center gap-3 px-2 mt-16 sm:mt-2">
        <Banner />
        <ProductSliderOffers title={"Discounts for you"} />
        {!loading && <ProductSlider title={"Suggested for You"} tagline={"Based on Your Activity"} />}
        <ProductSliderOffers title={"Top Offers On"} />
        <ProductSliderTop title={"Most Viewd Products"} />
      </main>
    </>
  );
};

export default Home;

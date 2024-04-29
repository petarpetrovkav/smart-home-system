import { lazy} from "react";

export {default as Home} from './Home/Home';

const Card = lazy(() => import('./Card/Card'));
const NotFound = lazy(() => import('./NotFound/NotFound'));
const Order = lazy(() => import('./Order/Order'));
const Product = lazy(() => import('./Product/Product'));
const Products = lazy(() => import('./Products/Products'));
const Login = lazy(() => import('./Register-Login/RegisterLogin'));
const Contact = lazy(() => import('./Contact/Contact'));

export { Card, NotFound, Order, Product, Products, Login, Contact };
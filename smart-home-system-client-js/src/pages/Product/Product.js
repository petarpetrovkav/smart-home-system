import './Product.scss'
import arrow_icon from '../../assets/images/breadcrum_arrow.png';
import {useParams} from "react-router-dom";
import React, {useContext, useEffect, useRef, useState} from "react";
import ProductService from "../../services/product";
import {ShopContext} from "../../context/ShopContext";

export default function Product() {
    const {id} = useParams();
    const [product, setProduct] = useState({});
    const {addToCart} = useContext(ShopContext);
    /*   const selectCategoryRef = useRef('');*/

    useEffect(() => {
       getProductById();
    }, []);

    const getProductById = async () => {
        const data = await ProductService.getProductById(id);
        console.log(data);
        setProduct(data);
    }

    return (
        <div id="product-display">
        <div className="product-display">
            <div className="product-display-left">
                <div className="product-display-img">
                    <img className="product-display-main-img" src={product.imageUrl} alt=""/>
                </div>
            </div>
            <div className="product-display-right">
                <h1>{product.productName}</h1>
                <div className="product-display-right-prices">
                    <div className="product-display-right-price-new">${product.price}</div>
                </div>
                <div className="product-display-right-description">
                    {product.description}
                </div>
                <button onClick={()=> {addToCart(product.id)}}>ADD TO CART</button>
            </div>
        </div>
        </div>
    );
}
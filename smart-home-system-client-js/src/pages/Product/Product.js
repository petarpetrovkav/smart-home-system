import './Product.scss'
import arrow_icon from '../../assets/images/breadcrum_arrow.png';
import {useParams} from "react-router-dom";
import React, {useContext, useEffect, useRef, useState} from "react";
import {useNavigate} from "react-router-dom";
import ProductService from "../../services/product";
import {ShopContext} from "../../context/ShopContext";

export default function Product() {
    const {id} = useParams();
    const [product, setProduct] = useState({});
    const {addToCart} = useContext(ShopContext);
    const navigate = useNavigate();
    const messageRefAdd = useRef(null);
    /*   const selectCategoryRef = useRef('');*/

    useEffect(() => {
       getProductById();
    }, []);

    const addCart = async (productId) => {
        try {
            const response = await addToCart(productId);
            messageRefAdd.current.innerText = response.responseMessage;
            console.log(messageRefAdd.current.innerText);
            if (response.isValid) {
                messageRefAdd.current.style.display = 'block';
                setTimeout(() => {
                    messageRefAdd.current.style.display = 'none';
                }, 3000);
            }
        } catch (error) {
            console.error('Error adding to cart:', error);
        }
    }

    const getProductById = async () => {
        const data = await ProductService.getProductById(id);
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
                </div>   {/*       addCart(product.productId)*/}
                <button onClick={()=> { localStorage.getItem('auth-token') ? addCart(product.productId) : navigate("/register-login")}}>ADD TO CART</button>
                <div ref={messageRefAdd} style={{display: 'none'}}></div>
            </div>
        </div>
        </div>
    );
}
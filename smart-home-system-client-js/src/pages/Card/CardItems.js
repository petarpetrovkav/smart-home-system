import React, {useContext} from "react";

import './CardItems.scss'
import {ShopContext} from "../../context/ShopContext";
import remove_icon from '../../assets/images/cart_cross_icon.png';


export default function CardItems() {

    const {getTotalCartAmount, allProducts,cartItems,removeFromCart} = useContext(ShopContext);

    return (
        <div id="card">
            <div className="cart-items">
                <div className="cart-items-format-main">
                    <p>Products</p>
                    <p>Title</p>
                    <p>Price</p>
                    <p>Quantity</p>
                    <p>Total</p>
                    <p>Remove</p>
                </div>
                <hr/>
               {/* {allProducts.map((item,index)=>{
                    console.log(item);
                    if (cartItems[item.id]>0)
                    {
                        return <div key={item.id}>
                            <div className="cart-items-format cart-items-format-main">
                                <img src={item.imageUrl} alt="" className="cart-icon-product-icon"/>
                                <p>{item.productName}</p>
                                <p>{item.price}</p>
                                <button className='cart-items-quantity'>{cartItems[item.id]}</button>
                                <p>${item.price*cartItems[item.id]}</p>
                                <img src={remove_icon} className="cart-items-remove-icon" onClick={() => {removeFromCart(item.id)}} alt=""/>
                            </div>
                            <hr/>
                        </div>
                    }
                    return null;
                })}*/}
                <div className="cart-items-down">
                    <div className="cart-items-total">
                        <h1>Cart Totals</h1>
                        <div>
                            <div className="cart-items-total-item">
                                <p>Subtotal</p>
                                <p>${getTotalCartAmount()}</p>
                            </div>
                            <hr/>
                            <div className="cart-items-total-item">
                                <p>Shipping Free</p>
                                <p>Free</p>
                            </div>
                            <hr/>
                            <div className="cart-items-total-item">
                                <h3>Total</h3>
                                <h3>${getTotalCartAmount()}</h3>
                            </div>
                        </div>
                        <button>PROCEED TO CHECKOUT</button>
                    </div>
                    <div className="cart-item-promo-code">

                    </div>
                </div>
            </div>
        </div>
    );
}
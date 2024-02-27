import React from "react";
import './Item.scss';
import {Link} from "react-router-dom";

export default function Item(props) {

    return (
        <>
            <div className='item'>
                <Link to={`/product/${props.item.productId}`}>
                <img onClick={window.scrollTo(0,0)} src={props.item.imageUrl} alt="" className='img'/>
                </Link>
                <p>{props.item.productName}</p>
                <div className="item-prices">
                    <div className="item-price">
                        ${props.item.price}
                    </div>
                </div>
            </div>
        </>);
}
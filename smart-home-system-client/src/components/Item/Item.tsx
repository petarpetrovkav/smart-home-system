import React from "react";
import IItem from '../../models/Interface/IItem';
import './Item.scss';
import p1_product from '../../assets/images/p1_product.png';

export default function Item(props: {item: IItem}) {
    const imagePath = require(`../../assets/images/${props.item.imageUrl}`).default;
    return (
        <>
            <div className='item' key={props.item.productId}>
                <img src={p1_product} alt="" className='img'/>
                <p>{props.item.productName}</p>
                <div className="item-prices">
                    <div className="item-price">
                        ${props.item.price}
                    </div>
                </div>
            </div>
        </>);
}
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import "./Styles.css";

const Home = () => {
    const [posts, setPosts] = useState();

    useEffect(() => {
        const getPosts = async () => {
            const { data } = await axios.get('api/post/getall');
            setPosts(data);
        }
        getPosts();
        console.log(posts)
    })
    return (
        <div className='container col-md-5'>
            {posts && posts.map((post, i) => {
               return ( <div key={i} className="mt-3">
                    <div>
                        <img src={post.imageUrl} alt="" width="500px"/>
                    </div>
                    <div>
                        <a href={post.link}><h3>{post.title}</h3></a>
                        <p>{post.text}</p>
                        </div>
                </div>
               )
            })}
        </div>
    )
}
export default Home;
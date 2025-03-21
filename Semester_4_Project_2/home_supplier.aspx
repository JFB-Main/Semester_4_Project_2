<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/HomeMaster.master" CodeBehind="home_supplier.aspx.cs" Inherits="Semester_4_Project_2.home_supplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes\Project_Theme\styles\homepage.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container-fluid section-hero">
            <h1>
                Integrity, Efficiency, Honesty and Pragmatic
            </h1>
        </div>

            <div class="divider">
            <div class="divider-text">
                <div class="divider-lowopacity">
                    INTRO   
                </div>
                <p>
                    ▼ // SIGMA
                </p>
                <h3>
                    Intro
                </h3>
            </div>
            <div class="divider-line">
        </div>
        </div>

        <div class="section-intro">
            <div class="about-intro-vision">
                <div class="about-intro-vision-title">
                    <h3>
                        Our Vision
                    </h3>
                </div>
                <div class="about-intro-vision-display">
                    <p class="vision-display-textEdit1">
                        Creating a supply depot for 
                    </p>
                    <p class="vision-display-textEdit2">
                        billions people in 2030s.
                    </p>
                </div>
            </div>
            <div class="about-intro-lenght">
                <div class="about-intro-lenght-title">
                    <h3>
                        About Us
                    </h3>
                </div>
                <div class="about-intro-lenght-desc">
                    <p>
                        Welcome to our company, your trusted partner for efficient and reliable warehousing solutions. With our state-of-the-art facilities, we provide flexible storage options tailored to meet the unique needs of your business.
                    </p>
                    <p>
                        Whether you're managing high-volume inventory, seasonal surges, or specialized goods, we ensure seamless operations, real-time tracking, and secure handling. Our team of experts is committed to optimizing your logistics, helping you save time, reduce costs, and focus on what matters most—growing your business.
                    </p>
                    <p>
                        Experience unparalleled service with our company, where your storage and distribution needs are always in good hands.
                    </p>
                </div>
            </div>
            <div class="about-intro-philosophy">
                <div class="about-intro-philosophy-title">
                    <h3>
                        • Our Philosophy •
                    </h3>
                </div>
                <div class="about-intro-philosophy-desc">
                    <p>
                        Innovative | efficient | customer-driven warehousing solutions.
                    </p>
                </div>
            </div>
        </div>
        <hr />
        <div class="divider">
            <div class="divider-text">
                <div class="divider-lowopacity">
                    SUPPLIER
                </div>
                <p>
                    ▼ // SIGMA
                </p>
                <h3>
                    Supplier
                </h3>
            </div>
            <div class="divider-line">
            </div>
        </div>
        <div class="content-supplier">
            <p class="sup-desc">
                This list features our invaluable suppliers, who play a pivotal role in not only establishing our company but also ensuring its continuous growth and success. Through their unwavering dedication and support, they exemplify a profound sense of trust, mutual benefit, and enduring friendship. Their contributions extend far beyond mere transactions; they form the backbone of our operations, constantly inspiring us with their commitment to excellence.
            </p>
            <div class="container-fluid supplier-container">
                <div class="supplier-row">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="row-content">
                                <img class="card-img" src='<%# Eval("image_path") %>' alt="Company Image"/>
                                <div class="card-name-line-group">
                                    <div class="card-line"></div>
                                    <p class="lead card-name">
                                        Name: <%# Eval("name") %>
                                    </p>
                                    <p class="card-desc">
                                        <%# Eval("description") %>
                                    </p>
                                </div>
                                <div class="card-yellow-block"></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </div>
</asp:Content>